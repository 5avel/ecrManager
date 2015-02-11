using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using ecrmini;

namespace ecrManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

         private DataTable _dataTable;
         private SqlDataAdapter adapter;

    public DataTable DataTable
    {
        get { return _dataTable; }
        set { _dataTable = value; }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {


           
        }

    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        string cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Pavel\Source\Repos\ecrmanager\ecrManager\ecrManager\Database.mdf;Integrated Security=True";

        SqlConnection conn = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Goods", conn);
        
        adapter = new SqlDataAdapter(cmd);
        SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
        this._dataTable = new DataTable("Goods");
        adapter.Fill(this._dataTable);
        this.grid1.DataContext = this;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        adapter.Update(this._dataTable);

        //t400 t = new t400();
        //t.t400me()
    }




    }
}
