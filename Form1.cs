using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using TextFileLibrary;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kurs
{
    public partial class Form1 : Form
    {

        private string currentFilePath = null;
        private bool isFileModified = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid((int)nudSystemSize.Value);
            dgvEquations.AllowUserToResizeColumns = false;
            dgvEquations.AllowUserToResizeRows = false;
            dgvEquations.CellValueChanged += dgvEquations_CellValueChanged;

        }

        private void InitializeGrid(int size)
        {
            dgvEquations.Columns.Clear();

            for (int i = 0; i < size; i++)
            {
                dgvEquations.Columns.Add($"x{i + 1}", $"x{i + 1}");
                dgvEquations.Columns[i].Width = 50;
            }

            dgvEquations.Columns.Add("free", "Свободный член");
            dgvEquations.Columns[size].Width = 80;

            dgvEquations.Rows.Clear();
            dgvEquations.Rows.Add(size);

            for (int i = 0; i < size; i++)
            {
                dgvEquations.Rows[i].HeaderCell.Value = $"Ур. {i + 1}";
            }
        }

        private void SolveSystem(double[,] matrix, double[] freeTerms)
        {
            Stopwatch sw = Stopwatch.StartNew();
            StringBuilder solutionText = new StringBuilder();
            int size = freeTerms.Length;

            if (!string.IsNullOrEmpty(currentFilePath))
            {
                string fileInfo = isFileModified ?
                    $"Файл: {System.IO.Path.GetFileName(currentFilePath)} (изменен)" :
                    $"Файл: {System.IO.Path.GetFileName(currentFilePath)}";

                solutionText.AppendLine(fileInfo);
                solutionText.AppendLine();
            }

            solutionText.AppendLine("ИСХОДНАЯ СИСТЕМА УРАВНЕНИЙ:");
            solutionText.AppendLine(GetSystemString(matrix, freeTerms));
            solutionText.AppendLine();

            // ПОДРОБНОЕ ВЫЧИСЛЕНИЕ ПО МЕТОДУ КРАМЕРА
            solutionText.AppendLine("РЕШЕНИЕ ПО МЕТОДУ КРАМЕРА:");
            solutionText.AppendLine();

            // Главный определитель
            solutionText.AppendLine("1. ВЫЧИСЛЕНИЕ ГЛАВНОГО ОПРЕДЕЛИТЕЛЯ (Δ):");
            solutionText.AppendLine("Исходная матрица:");
            solutionText.AppendLine(GetMatrixString(matrix));

            double mainDet = CalculateDeterminantWithSteps(matrix, solutionText, "Δ");
            solutionText.AppendLine($"ГЛАВНЫЙ ОПРЕДЕЛИТЕЛЬ Δ = {mainDet:F5}");
            solutionText.AppendLine();

            if (Math.Abs(mainDet) < 1e-10)
            {
                solutionText.AppendLine("ОШИБКА: Система вырождена (главный определитель равен 0)");
                rtbSolution.Text = solutionText.ToString();
                return;
            }

            // Вычисление определителей для каждой переменной
            double[] solutions = new double[size];
            solutionText.AppendLine("2. ВЫЧИСЛЕНИЕ ВСПОМОГАТЕЛЬНЫХ ОПРЕДЕЛИТЕЛЕЙ:");

            for (int i = 0; i < size; i++)
            {
                solutionText.AppendLine();
                solutionText.AppendLine($"ОПРЕДЕЛИТЕЛЬ Δ{i + 1} (замена {i + 1}-го столбца на свободные члены):");

                double[,] modifiedMatrix = ReplaceColumn(matrix, freeTerms, i);
                solutionText.AppendLine(GetMatrixString(modifiedMatrix));

                double detI = CalculateDeterminantWithSteps(modifiedMatrix, solutionText, $"Δ{i + 1}");
                solutions[i] = detI / mainDet;

                solutionText.AppendLine($"Δ{i + 1} = {detI:F5}");
                solutionText.AppendLine($"x{i + 1} = Δ{i + 1} / Δ = {detI:F5} / {mainDet:F5} = {solutions[i]:F5}");
            }

            solutionText.AppendLine();

            // ПОДРОБНОЕ ВЫЧИСЛЕНИЕ ЧИСЛА ОБУСЛОВЛЕННОСТИ
            solutionText.AppendLine("3. ВЫЧИСЛЕНИЕ ЧИСЛА ОБУСЛОВЛЕННОСТИ:");
            double cond = CalculateConditionNumberWithSteps(matrix, solutionText);

            string conditionMessage = $"ЧИСЛО ОБУСЛОВЛЕННОСТИ: {cond:F2}\n";
            conditionMessage += cond > 20 ?
                "СИСТЕМА ПЛОХО ОБУСЛОВЛЕНА! Решение может быть неточным." :
                "СИСТЕМА ХОРОШО ОБУСЛОВЛЕННА.";

            MessageBox.Show(conditionMessage, "Информация об обусловленности",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);

            solutionText.AppendLine(conditionMessage);
            solutionText.AppendLine();

            // Выводим решение
            solutionText.AppendLine("4. РЕЗУЛЬТАТ:");
            for (int i = 0; i < size; i++)
            {
                solutionText.AppendLine($"x{i + 1} = {solutions[i]:F5}");
            }

            // Добавляем информацию о времени выполнения
            sw.Stop();
            solutionText.AppendLine($"\nВремя решения: {sw.Elapsed.TotalMilliseconds:F2} мс");

            rtbSolution.Text = solutionText.ToString();
            SolveSystemBrief(matrix, freeTerms);
        }

        private void SolveSystemBrief(double[,] matrix, double[] freeTerms)
        {
            Stopwatch sw = Stopwatch.StartNew();
            StringBuilder solutionText = new StringBuilder();
            int size = freeTerms.Length;

            // Заголовок и исходная система
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                string fileInfo = isFileModified ?
                    $"Файл: {System.IO.Path.GetFileName(currentFilePath)} (изменен)" :
                    $"Файл: {System.IO.Path.GetFileName(currentFilePath)}";
                solutionText.AppendLine(fileInfo);
                solutionText.AppendLine();
            }

            try
            {
                // Вычисляем главный определитель
                double mainDet = CalculateDeterminantOptimized(matrix);
                solutionText.AppendLine($"Главный определитель Δ = {mainDet:F5}");
                solutionText.AppendLine();

                if (Math.Abs(mainDet) < 1e-10)
                {
                    solutionText.AppendLine("❌ СИСТЕМА ВЫРОЖДЕНА");
                    solutionText.AppendLine("Определитель равен нулю, решение не существует или не единственно");
                    DisplayBriefSolution(solutionText, sw);
                    return;
                }

                // Вычисляем решения методом Крамера
                double[] solutions = new double[size];
                for (int i = 0; i < size; i++)
                {
                    double[,] modifiedMatrix = ReplaceColumn(matrix, freeTerms, i);
                    double detI = CalculateDeterminantOptimized(modifiedMatrix);
                    solutions[i] = detI / mainDet;
                }

                // Выводим результаты
                solutionText.AppendLine("РЕШЕНИЕ СИСТЕМЫ:");
                for (int i = 0; i < size; i++)
                {
                    solutionText.AppendLine($"x{i + 1} = {solutions[i]:F6}");
                }
                solutionText.AppendLine();

                // Проверка обусловленности
                double cond = CalculateConditionNumber(matrix);
                solutionText.AppendLine($"Число обусловленности: {cond:F2}");

                if (cond > 20)
                    solutionText.AppendLine("⚠️  Система плохо обусловлена");
                else
                    solutionText.AppendLine("✅ Система хорошо обусловлена");

                solutionText.AppendLine();

                // Проверка решения (невязка)
                solutionText.AppendLine("ПРОВЕРКА РЕШЕНИЯ:");
                double maxError = CalculateSolutionError(matrix, freeTerms, solutions);
                solutionText.AppendLine($"Максимальная невязка: {maxError:E2}");

                if (maxError < 1e-10)
                    solutionText.AppendLine("✅ Решение точное");
                else if (maxError < 1e-5)
                    solutionText.AppendLine("✅ Решение достаточно точное");
                else
                    solutionText.AppendLine("⚠️  Решение имеет значительную погрешность");

            }
            catch (Exception ex)
            {
                solutionText.AppendLine($"❌ ОШИБКА: {ex.Message}");
            }

            DisplayBriefSolution(solutionText, sw);
        }

        private void DisplayBriefSolution(StringBuilder sb, Stopwatch sw)
        {
            sw.Stop();
            sb.AppendLine($"\nВремя решения: {sw.Elapsed.TotalMilliseconds:F2} мс");

            // Выводим в richTextBox1 (первая вкладка) - краткий вариант
            richTextBox1.Text = sb.ToString();
        }

        // ==================== МЕТОД ДЛЯ ВЫЧИСЛЕНИЯ НЕВЯЗКИ ====================
        double CalculateSolutionError(double[,] matrix, double[] freeTerms, double[] solutions)
        {
            int size = freeTerms.Length;
            double maxError = 0;  // Здесь будет максимальная невязка

            for (int i = 0; i < size; i++)  // Перебираем ВСЕ уравнения
            {
                double sum = 0;
                for (int j = 0; j < size; j++)
                {
                    //левая часть уравнения с найденным решением
                    sum += matrix[i, j] * solutions[j];
                }

                // (разница между вычисленным и должным
                double error = Math.Abs(sum - freeTerms[i]);

                if (error > maxError) maxError = error;  // Ищем максимальную невязку
            }

            return maxError;  // Возвращаем максимальную невязку
        }


        private double[,] ReplaceColumn(double[,] matrix, double[] newColumn, int columnIndex)
        {
            int size = matrix.GetLength(0);
            double[,] result = (double[,])matrix.Clone();

            for (int i = 0; i < size; i++)
            {
                result[i, columnIndex] = newColumn[i];
            }

            return result;
        }

        private double CalculateDeterminantWithSteps(double[,] matrix, StringBuilder sb, string determinantName)
        {
            int n = matrix.GetLength(0);
            double det = 1;
            double[,] tempMatrix = (double[,])matrix.Clone();

            sb.AppendLine($"Вычисление {determinantName} методом Гаусса:");

            for (int i = 0; i < n; i++)
            {
                // Поиск ведущего элемента
                int maxRow = i;
                double maxVal = Math.Abs(tempMatrix[i, i]);
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(tempMatrix[k, i]) > maxVal)
                    {
                        maxVal = Math.Abs(tempMatrix[k, i]);
                        maxRow = k;
                    }
                }

                // Перестановка строк
                if (maxRow != i)
                {
                    sb.AppendLine($"  Перестановка строк {i + 1} и {maxRow + 1}");
                    for (int k = 0; k < n; k++)
                    {
                        double temp = tempMatrix[i, k];
                        tempMatrix[i, k] = tempMatrix[maxRow, k];
                        tempMatrix[maxRow, k] = temp;
                    }
                    det *= -1;
                    sb.AppendLine($"  Множитель: -1 (текущий det = {det:F5})");
                }

                // Если ведущий элемент нулевой - определитель 0
                if (Math.Abs(tempMatrix[i, i]) < 1e-10)
                {
                    sb.AppendLine($"  Нулевой ведущий элемент - определитель = 0");
                    return 0;
                }

                // Умножение на диагональный элемент
                double diagElement = tempMatrix[i, i];
                det *= diagElement;
                sb.AppendLine($"  Умножение на диагональный элемент a[{i + 1},{i + 1}] = {diagElement:F5}");
                sb.AppendLine($"  Текущий det = {det:F5}");

                // Исключение переменной из других уравнений
                for (int k = i + 1; k < n; k++)
                {
                    double factor = tempMatrix[k, i] / tempMatrix[i, i];
                    for (int j = i; j < n; j++)
                    {
                        tempMatrix[k, j] -= factor * tempMatrix[i, j];
                    }
                }
            }

            sb.AppendLine($"Финальное значение {determinantName} = {det:F5}");
            return det;
        }


        private double CalculateConditionNumberWithSteps(double[,] matrix, StringBuilder sb)
        {
            int size = matrix.GetLength(0);

            sb.AppendLine("Норма матрицы A:");
            double normA = 0;
            for (int i = 0; i < size; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < size; j++)
                {
                    rowSum += Math.Abs(matrix[i, j]);
                }
                sb.AppendLine($"  Строка {i + 1}: {rowSum:F5}");
                if (rowSum > normA) normA = rowSum;
            }
            sb.AppendLine($"‖A‖ = {normA:F5}");
            sb.AppendLine();

            try
            {
                sb.AppendLine("Обратная матрица A⁻¹:");
                double[,] inverse = GetInverseMatrix(matrix);
                sb.AppendLine(GetMatrixString(inverse));

                sb.AppendLine("Норма обратной матрицы A⁻¹:");
                double normInv = 0;
                for (int i = 0; i < size; i++)
                {
                    double rowSum = 0;
                    for (int j = 0; j < size; j++)
                    {
                        rowSum += Math.Abs(inverse[i, j]);
                    }
                    sb.AppendLine($"  Строка {i + 1}: {rowSum:F5}");
                    if (rowSum > normInv) normInv = rowSum;
                }
                sb.AppendLine($"‖A⁻¹‖ = {normInv:F5}");
                sb.AppendLine();

                double cond = normA * normInv;
                sb.AppendLine($"Число обусловленности: ‖A‖ × ‖A⁻¹‖ = {normA:F5} × {normInv:F5} = {cond:F5}");

                return cond;
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Ошибка вычисления обратной матрицы: {ex.Message}");
                return double.PositiveInfinity;
            }
        }

        private string GetMatrixString(double[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                sb.Append("  ");
                for (int j = 0; j < size; j++)
                {
                    sb.Append($"{matrix[i, j],8:F3} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }



        // Метод Гаусса для решения СЛАУ
        private double[] SolveWithGauss(double[,] matrix, double[] freeTerms)
        {
            int n = freeTerms.Length;
            double[] result = new double[n];

            // Прямой ход метода Гаусса
            for (int i = 0; i < n; i++)
            {
                // Поиск ведущего элемента
                int maxRow = i;
                double maxVal = Math.Abs(matrix[i, i]);
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(matrix[k, i]) > maxVal)
                    {
                        maxVal = Math.Abs(matrix[k, i]);
                        maxRow = k;
                    }
                }

                // Перестановка строк
                if (maxRow != i)
                {
                    for (int k = 0; k < n; k++)
                    {
                        double temp = matrix[i, k];
                        matrix[i, k] = matrix[maxRow, k];
                        matrix[maxRow, k] = temp;
                    }
                    double tempTerm = freeTerms[i];
                    freeTerms[i] = freeTerms[maxRow];
                    freeTerms[maxRow] = tempTerm;
                }

                // Нормализация текущей строки
                double div = matrix[i, i];
                if (Math.Abs(div) < 1e-10)
                    throw new Exception("Система вырождена или плохо обусловлена");

                for (int j = i; j < n; j++)
                {
                    matrix[i, j] /= div;
                }
                freeTerms[i] /= div;

                // Исключение переменной из других уравнений
                for (int k = i + 1; k < n; k++)
                {
                    double factor = matrix[k, i];
                    for (int j = i; j < n; j++)
                    {
                        matrix[k, j] -= factor * matrix[i, j];
                    }
                    freeTerms[k] -= factor * freeTerms[i];
                }
            }

            // Обратный ход метода Гаусса
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = freeTerms[i];
                for (int j = i + 1; j < n; j++)
                {
                    result[i] -= matrix[i, j] * result[j];
                }
            }

            return result;
        }

        // Оптимизированное вычисление определителя через метод Гаусса
        private double CalculateDeterminantOptimized(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double det = 1;
            double[,] tempMatrix = (double[,])matrix.Clone();

            for (int i = 0; i < n; i++)
            {
                // Поиск ведущего элемента
                int maxRow = i;
                double maxVal = Math.Abs(tempMatrix[i, i]);
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(tempMatrix[k, i]) > maxVal)
                    {
                        maxVal = Math.Abs(tempMatrix[k, i]);
                        maxRow = k;
                    }
                }

                // Перестановка строк (меняет знак определителя)
                if (maxRow != i)
                {
                    for (int k = 0; k < n; k++)
                    {
                        double temp = tempMatrix[i, k];
                        tempMatrix[i, k] = tempMatrix[maxRow, k];
                        tempMatrix[maxRow, k] = temp;
                    }
                    det *= -1;
                }

                // Если ведущий элемент нулевой - определитель 0
                if (Math.Abs(tempMatrix[i, i]) < 1e-10)
                {
                    return 0;
                }

                det *= tempMatrix[i, i];

                // Исключение переменной из других уравнений
                for (int k = i + 1; k < n; k++)
                {


                    double factor = tempMatrix[k, i] / tempMatrix[i, i];
                    for (int j = i; j < n; j++)
                    {
                        tempMatrix[k, j] -= factor * tempMatrix[i, j];
                    }
                }
            }

            return det;
        }

        // Остальные методы остаются без изменений
        private string GetSystemString(double[,] matrix, double[] freeTerms)
        {
            StringBuilder sb = new StringBuilder();
            int size = freeTerms.Length;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j != 0 && matrix[i, j] >= 0) sb.Append(" + ");
                    else if (j != 0) sb.Append(" - ");
                    else if (matrix[i, j] < 0) sb.Append("-");

                    sb.Append($"{Math.Abs(matrix[i, j]):F2}x{j + 1}");
                }
                sb.AppendLine($" = {freeTerms[i]:F2}");
            }

            return sb.ToString();
        }

        private double CalculateConditionNumber(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double norm = 0;

            for (int i = 0; i < size; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < size; j++)
                {
                    rowSum += Math.Abs(matrix[i, j]);
                }
                if (rowSum > norm) norm = rowSum;
            }

            try
            {
                double[,] inverse = GetInverseMatrix(matrix);
                double invNorm = 0;

                for (int i = 0; i < size; i++)
                {
                    double rowSum = 0;
                    for (int j = 0; j < size; j++)
                    {
                        rowSum += Math.Abs(inverse[i, j]);
                    }
                    if (rowSum > invNorm) invNorm = rowSum;
                }

                return norm * invNorm;
            }
            catch
            {
                return double.PositiveInfinity;
            }
        }

        private double[,] GetInverseMatrix(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double[,] inverse = new double[size, size];
            double det = CalculateDeterminantOptimized(matrix);

            if (Math.Abs(det) < 1e-10)
                throw new Exception("Матрица вырождена");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double[,] minor = GetMinor(matrix, i, j);
                    inverse[j, i] = Math.Pow(-1, i + j) * CalculateDeterminantOptimized(minor) / det;
                }
            }

            return inverse;
        }

        private double[,] GetMinor(double[,] matrix, int row, int col)
        {
            int size = matrix.GetLength(0);
            double[,] minor = new double[size - 1, size - 1];

            for (int i = 0, m = 0; i < size; i++)
            {
                if (i == row) continue;
                for (int j = 0, n = 0; j < size; j++)
                {
                    if (j == col) continue;
                    minor[m, n] = matrix[i, j];
                    n++;
                }
                m++;
            }

            return minor;
        }

        // Остальные методы обработки событий остаются без изменений
        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Сохранить решение"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveDialog.FileName, rtbSolution.Text);
                    MessageBox.Show("Решение успешно сохранено", "Сохранение",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveMatrix_Click(object sender, EventArgs e)
        {
            // Если файл уже открыт и не изменялся, сохраняем в него
            if (!string.IsNullOrEmpty(currentFilePath) && !isFileModified)
            {
                SaveSystemToFile(currentFilePath);
                return;
            }

            // Иначе открываем диалог сохранения
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Сохранить систему уравнений",
                FileName = string.IsNullOrEmpty(currentFilePath) ? "system.txt" : System.IO.Path.GetFileName(currentFilePath)
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveSystemToFile(saveDialog.FileName);
            }
        }

        private bool SaveSystemToFile(string filePath)
        {
            try
            {
                int size = (int)nudSystemSize.Value;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        // Берем значение из DataGridView или 0 если null
                        object cellValue = dgvEquations.Rows[i].Cells[j].Value;
                        string valueStr = cellValue?.ToString() ?? "0";

                        // Записываем число
                        sb.Append(valueStr);

                        // Добавляем разделитель (табуляция или пробел)
                        if (j < size - 1)
                            sb.Append("\t");
                    }

                    // Добавляем свободный член
                    object freeTermValue = dgvEquations.Rows[i].Cells[size].Value;
                    string freeTermStr = freeTermValue?.ToString() ?? "0";
                    sb.Append("\t");
                    sb.Append(freeTermStr);

                    sb.AppendLine();
                }

                // Сохраняем в файл
                System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                // Обновляем информацию о файле
                currentFilePath = filePath;
                isFileModified = false;

                MessageBox.Show("Система успешно сохранена в файл", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbSolution.Text))
            {
                Clipboard.SetText(rtbSolution.Text);
                MessageBox.Show("Решение скопировано в буфер обмена", "Копирование",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nudSystemSize_ValueChange(object sender, EventArgs e)
        {
            InitializeGrid((int)nudSystemSize.Value);
        }

        private void btnRandomize_Click_1(object sender, EventArgs e)
        {
            int size = (int)nudSystemSize.Value;
            Random rand = new Random();

            currentFilePath = null;
            isFileModified = false;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dgvEquations.Rows[i].Cells[j].Value = rand.Next(-10, 10);
                }
                dgvEquations.Rows[i].Cells[size].Value = rand.Next(-20, 20);
            }
        }

        private void btnSolve_Click_1(object sender, EventArgs e)
        {
            try
            {
                int size = (int)nudSystemSize.Value;
                double[,] matrix = new double[size, size];
                double[] freeTerms = new double[size];

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (dgvEquations.Rows[i].Cells[j].Value == null)
                        {
                            MessageBox.Show($"Введите значение для x{j + 1} в уравнении {i + 1}",
                                          "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        matrix[i, j] = Convert.ToDouble(dgvEquations.Rows[i].Cells[j].Value);
                    }

                    if (dgvEquations.Rows[i].Cells[size].Value == null)
                    {
                        MessageBox.Show($"Введите свободный член для уравнения {i + 1}",
                                      "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    freeTerms[i] = Convert.ToDouble(dgvEquations.Rows[i].Cells[size].Value);
                }

                SolveSystem(matrix, freeTerms);
                tabControlMain.SelectedTab = tabSolution;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
        }

        private void btnCopySolution_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtbSolution.Text);
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Загрузить систему уравнений",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadSystemFromFile(openFileDialog.FileName))
                {
                    // Переходим на вкладку с уравнениями
                    tabControlMain.SelectedIndex = 0;
                }
            }
        }

        private bool LoadSystemFromFile(string filePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);

                // Определяем размер системы по количеству строк
                int size = lines.Length;
                if (size == 0)
                {
                    MessageBox.Show("Файл пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Устанавливаем размер системы
                nudSystemSize.Value = size;
                InitializeGrid(size);

                double[,] matrix = new double[size, size];
                double[] freeTerms = new double[size];

                for (int i = 0; i < size; i++)
                {
                    string line = lines[i].Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    string[] elements = line.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (elements.Length != size + 1)
                    {
                        MessageBox.Show($"Неверное количество элементов в строке {i + 1}. Ожидается {size + 1}, получено {elements.Length}",
                                      "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    for (int j = 0; j < size; j++)
                    {
                        if (!double.TryParse(elements[j], out matrix[i, j]))
                        {
                            MessageBox.Show($"Ошибка преобразования числа в строке {i + 1}, столбец {j + 1}",
                                          "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        dgvEquations.Rows[i].Cells[j].Value = elements[j];
                    }

                    if (!double.TryParse(elements[size], out freeTerms[i]))
                    {
                        MessageBox.Show($"Ошибка преобразования свободного члена в строке {i + 1}",
                                      "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    dgvEquations.Rows[i].Cells[size].Value = elements[size];
                }

                // Сохраняем путь к файлу и сбрасываем флаг изменений
                currentFilePath = filePath;
                isFileModified = false;

                MessageBox.Show("Система успешно загружена из файла", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK,

                MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(currentFilePath) && !isFileModified)
            {
                SaveToFile(currentFilePath);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Сохранить систему уравнений",
                FileName = string.IsNullOrEmpty(currentFilePath) ? "system.txt" : System.IO.Path.GetFileName(currentFilePath)
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (SaveToFile(saveDialog.FileName))
                {
                    currentFilePath = saveDialog.FileName;
                    isFileModified = false;
                }
            }
        }

        private bool SaveToFile(string filePath)
        {
            try
            {
                int size = (int)nudSystemSize.Value;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sb.Append(dgvEquations.Rows[i].Cells[j].Value?.ToString() ?? "0");
                        sb.Append("\t"); // Табуляция как разделитель
                    }
                    sb.Append(dgvEquations.Rows[i].Cells[size].Value?.ToString() ?? "0");
                    sb.AppendLine();
                }

                System.IO.File.WriteAllText(filePath, sb.ToString());

                MessageBox.Show("Система успешно сохранена", "Сохранение",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvEquations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isFileModified && !string.IsNullOrEmpty(currentFilePath))
            {
                isFileModified = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentFilePath = null;
            isFileModified = false;

            int size = (int)nudSystemSize.Value;
            InitializeGrid(size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string textToPrint = rtbSolution.Text;

                // Указываем шрифт для печати (можно использовать шрифт из RichTextBox)
                Font printFont = rtbSolution.Font;

                // Создаем экземпляр TextFilePrinter и печатаем текст
                TextFilePrinter printer = new TextFilePrinter();
                printer.PrintText(textToPrint, printFont);

                MessageBox.Show("Документ отправлен на печать.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = rtbSolution.Font;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbSolution.Font = fontDialog1.Font;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}