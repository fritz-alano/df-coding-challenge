namespace api.DBModels
{
  public class Project
  {
    public Project()
    {
      this.Users = new HashSet<User>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; }
  }
}
