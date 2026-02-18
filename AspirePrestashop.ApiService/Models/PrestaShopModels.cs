namespace AspirePrestashop.ApiService.Models;

public record Product(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    bool Active,
    string Reference,
    string ImageUrl
);

public record Category(
    int Id,
    string Name,
    string Description,
    int ParentId,
    bool Active
);

public record Customer(
    int Id,
    string Email,
    string FirstName,
    string LastName,
    DateTime DateAdd
);

public record Order(
    int Id,
    string Reference,
    decimal TotalPaid,
    string PaymentMethod,
    DateTime DateAdd,
    string CurrentState
);