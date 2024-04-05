using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<PlaceReview> PlaceReviews { get; set; } = new List<PlaceReview>();

    public virtual ICollection<VacationPlan> VacationPlans { get; set; } = new List<VacationPlan>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
