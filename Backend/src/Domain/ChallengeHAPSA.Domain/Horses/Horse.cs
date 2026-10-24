using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Entities;
using ChallengeHAPSA.Domain.Common.Enums;

namespace ChallengeHAPSA.Domain.Horses
{
    public class Horse : Entity
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public bool Status { get; private set; }

        // ctor privado para respetar un poco mejor ddd (invariants al crear)
        private Horse()
        {

        }

        private Horse(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Status = true;
        }

        public static Result<Horse> Create(string name, DateTime birthday)
        {
            var validation = ValidateName(name);

            if (validation.IsFailure)
                return validation.Error!;

            return new Horse(name, birthday);
        }

        public Result Rename(string name)
        {
            var validation = ValidateName(name);

            if (validation.IsFailure)
                return validation;

            this.Name = name;
            return Result.Success();
        }

        public Result Disable()
        {
            if (!this.Status)
                return ErrorCodes.HORSE_ALREADY_DISABLED;

            this.Status = false;
            return Result.Success();
        }

        public Result Enable()
        {
            this.Status = true;
            return Result.Success();
        }

        private static Result ValidateName(string name)
        {
            // validacion random de ejemplo
            if (name == "asdasd123")
                return ErrorCodes.HORSE_NAME_NOT_ALLOWED;

            return Result.Success();
        }
    }
}
