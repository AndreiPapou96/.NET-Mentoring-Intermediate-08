namespace Adapter.Task1
{
    internal class MyPrinterAdapter : IMyPrinter
    {
        private Printer printer;

        public MyPrinterAdapter(Printer printer)
        {
            this.printer = printer;
        }

        public void Print<T>(IElements<T> elements)
        {
            var container = new MyContainer<T>(elements.GetElements());
            printer.Print(container);
            //throw new System.NotImplementedException();
        }
    }
}