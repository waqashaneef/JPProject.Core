using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Admin.Domain.Validations.Client;

namespace JPProject.Admin.Domain.Validations.ApiResource
{
    public class RemoveApiSecretCommandValidation : ApiSecretValidation<RemoveApiSecretCommand>
    {
        public RemoveApiSecretCommandValidation()
        {
            ValidateResourceName();
            ValidateType();
            ValidateValue();
        }
    }
}