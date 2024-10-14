using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisterExpenseJson();
    }
    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
            throw new ArgumentException("Title is required");
        
        if (DateTime.Compare(request.Date, DateTime.UtcNow) > 0)
            throw new ArgumentException("Expense cannot be for the future");
        
        if (request.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.paymentType);
        if (paymentTypeIsValid)
            throw new ArgumentException("Payment Type is not valid");
        
    }
}
