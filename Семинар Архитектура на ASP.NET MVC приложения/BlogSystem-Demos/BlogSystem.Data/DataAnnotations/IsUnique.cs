namespace BlogSystem.Data.DataAnnotations
{
    using System.ComponentModel.DataAnnotations;

    class IsUnique : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
