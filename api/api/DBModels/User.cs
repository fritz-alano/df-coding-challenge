namespace api.DBModels
{
  public class User
  {
    public User()
    {
      this.Projects = new HashSet<Project>();
    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Project> Projects { get; set; }
  }
}
