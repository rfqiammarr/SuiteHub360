using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Supplier.Queries;

public class GetSupplierResponse : Response
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = default!;
}
