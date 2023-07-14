namespace SaveFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
             
            //MessageBox.Show(openFileDialog1.SafeFileName);
           // string path = @"D:\آموزش\رزومه\Code\Streams\SaveFile\pictures";
            //File.Copy(openFileDialog1.FileName, path + openFileDialog1.SafeFileName);
            //File.Copy(openFileDialog1.FileName,Path.Combine(path , openFileDialog1.SafeFileName));
            
        }
    }
}