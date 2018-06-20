namespace Study.Api.Requests.v1
{
    using System.Collections.Generic;
    using System.Linq;
    using Study.Api.Form;

    public abstract class ValidationRequest
    {
        public abstract IEnumerable<IValidator> Validators { get; }

        public void Valid()
        {
            var errors = (Validators ?? new IValidator[0]).Where(validator => !validator.Valid()).Select(validator => new ValidationError(validator.Field, validator.Message)).ToArray();

            if (errors.Length > 0)
            {
                throw new RequestInvalidException(errors);
            }
        }
    }
}
