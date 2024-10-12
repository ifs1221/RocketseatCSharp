using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = 1,
            Name = "Rex",
            Birthday = new DateTime(year: 2019, month: 1, day: 1),
            Type = PetType.Dog,
        };
    }
}
