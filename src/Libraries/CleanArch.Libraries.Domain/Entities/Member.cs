
using CleanArch.Libraries.Domain.Validation;

namespace CleanArch.Libraries.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member(string firstName, string lastName, string gender, string email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    public Member(int id, string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(id < 0, "Invalid Id value;");
        ValidateDomain(firstName, lastName, gender, email, active);
        Id = id;
    }

    public void Update(string firstName, string lastName, string gender, string email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(string.IsNullOrEmpty(firstName), "Invalid name. FirstName is required");

        DomainValidation.When(firstName.Length < 3, "Invalid name, too short, minimun 3 characters");

        DomainValidation.When(string.IsNullOrEmpty(lastName), "Invalid lastName. lastName is required");

        DomainValidation.When(lastName.Length < 3, "Invalid lastName, too short, minimun 3 characters");

        DomainValidation.When(email?.Length > 250, "Invalid email, too long, maximum 250 characters");

        DomainValidation.When(email?.Length < 6, "Invalid email, too short, minimun 6 characters");

        DomainValidation.When(string.IsNullOrEmpty(gender), "Invalid gender. gender is required");

        DomainValidation.When(!active.HasValue, "Must define activity");

        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = active;
    }
}
