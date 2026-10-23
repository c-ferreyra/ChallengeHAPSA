using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Entities;
using ChallengeHAPSA.Domain.Common.Enums;

namespace ChallengeHAPSA.Domain.Horses
{
    public class Horse : Entity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; private set; }

        // ctor privado para respetar un poco mejor ddd (invariants al crear)
        private Horse()
        {

        }

        private Horse(string name)
        {
            this.Name = name;
            this.CreationDate = DateTime.Now;
            this.IsActive = true;
        }

        public static Result<Horse> Create(string name)
        {
            // validacion random de ejemplo
            if (name == "asdasd123")
                return ErrorCodes.HORSE_NAME_NOT_ALLOWED;

            return new Horse(name);
        }

        public Result Disable()
        {
            if (!this.IsActive)
                return ErrorCodes.HORSE_ALREADY_DISABLED;

            this.IsActive = false;
            return Result.Success();
        }

        public Result Enable()
        {
            this.IsActive = true;
            return Result.Success();
        }
    }
}
