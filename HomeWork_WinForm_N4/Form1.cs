namespace HomeWork_WinForm_N4
{
    //Задание 3
    //Разработайте приложение, которое состоит из двух форм.
    //Первая форма содержит TextBox, доступный только для чтения,
    //и две кнопки "загрузить файл" и "редактировать".
    //Кнопка "редактировать" изначально неактивна.
    //При нажатиии на первую кнопку открывается диалог и пользователю предлагают выбрать текстовый файл.
    //Выбранный файл загружается в TextBox и кнопка "редактировать" становится активной.
    //При нажатии на вторую кнопку открывается вторая форма (не модально),
    //которая содержит TextBox доступный для редактирования и две кнопки "Сохранить" и "Отменить".
    //При нажатии на первую кнопку изменения отображаются в TextBox первой формы.

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string fileName;
        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files (*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;
                StreamReader sr = File.OpenText(fileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            buttonEdit.Enabled = true;
        }
        Form2 editForm = null;
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (editForm != null) editForm.Close();

            editForm = new Form2(textBox1.Text, fileName);

            editForm.FormClosing += (sender1, e1) =>
            {
                textBox1.Text = editForm.sourceText;
            };

            editForm.Show();
        }
    }
}