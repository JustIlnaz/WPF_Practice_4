using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string currentInput = ""; // Текущий ввод пользователя
        private string lastOperation = ""; // Последняя операция

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на цифровую кнопку
        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            currentInput += btn.Tag.ToString();
            ResultTextBox.Text = currentInput;
        }

        // Обработчик нажатия на операционную кнопку
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            lastOperation = btn.Tag.ToString();
            currentInput += " " + lastOperation + " ";
            ResultTextBox.Text = currentInput;
        }

        // Обработчик нажатия на кнопку "="
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = EvaluateExpression(currentInput);
                ResultTextBox.Text = result.ToString();
                currentInput = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вычисления: " + ex.Message);
            }
        }

        // Обработчик нажатия на кнопку "C" (очистка)
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            lastOperation = "";
            ResultTextBox.Text = "0";
        }

        // Метод для вычисления выражения
        private double EvaluateExpression(string expression)
        {
            try
            {
                // Используем простой парсинг и вычисление
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression, null);
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                throw new Exception("Неверное выражение");
            
            }
        }

       // Проверка ввода
  
    }
}