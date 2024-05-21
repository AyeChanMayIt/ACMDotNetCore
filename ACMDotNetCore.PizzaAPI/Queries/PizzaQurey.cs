namespace ACMDotNetCore.PizzaAPI.Queries
{
    public class PizzaQurey
    {
        public static string PizzaOrderQuery { get; } =
        @"Select po.*,p.PizzaName,p.Price From [dbo].[Tbl_PizzaOrder] po
        Inner Join Tbl_Pizza p on p.PizzaId=po.PizzaId
        Where PizzaOrderInvoiceNo=@PizzaOrderInvoiceNo;";
        public static string PizzaOrderDetailQuery { get; } =
        @"Select pod.*,pe.ExtraPizzaName,pe.ExtraPrice From [dbo].Tbl_PizzaOrderDetail pod
        Inner Join Tbl_ExtraPizza pe on pod.ExtraPizzaId=pe.ExtraPizzaId
        Where PizzaOrderInvoiceNo=@PizzaOrderInvoiceNo;";


    }
}
