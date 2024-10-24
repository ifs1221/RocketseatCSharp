using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

/// <summary>
/// Builder class for creating instances of RequestRegisterExpenseJson with fake data.
/// </summary>
public class RequestRegisterExpenseJsonBuilder
{
    /// <summary>
    /// Builds a new instance of RequestRegisterExpenseJson with fake data.
    /// </summary>
    /// <returns>A new instance of RequestRegisterExpenseJson.</returns>
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>());
    }
}
