using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Commands;

public class SupplierResponse : Response
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = default!;
}
