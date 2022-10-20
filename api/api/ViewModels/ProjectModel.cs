namespace api.ViewModels
{
  public class ProjectModel
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public List<UserModel> Users { get; set; }
  }
}
