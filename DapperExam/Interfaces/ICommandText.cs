namespace DapperExam.Interfaces
{
    public interface ICommandText
    {
        string GetProducts { get; }
        string GetProductById { get; }
        string AddProduct { get; }
        string UpdateProduct { get; }
        string RemoveProduct { get; }
    }

    public class CommandText : ICommandText
    {
        public string GetProducts => "Select * From Product";

        public string GetProductById => "Select * From Product Where Id=@Id";

        public string AddProduct => "Insert Into Product (Name,Cost,CreateDate) Values (@Name,@Cost,@CreateDate)";

        public string UpdateProduct => "Update Product Set Name=@Name,Cost=@Cost,CreateDate=@CreateDate Where Id=@Id";

        public string RemoveProduct => "Delete From Product Where Id=@Id";
    }
}