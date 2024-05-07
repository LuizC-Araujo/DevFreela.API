using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = EProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public EProjectStatusEnum Status { get; set; }
        public List<ProjectComment> Comments { get; set; }

        public void Cancel()
        {
            if (Status == EProjectStatusEnum.InProgress || Status == EProjectStatusEnum.Created)
                Status = EProjectStatusEnum.Cancelled;
        }

        public void Suspend()
        {
            if (Status == EProjectStatusEnum.InProgress || Status == EProjectStatusEnum.Created)
                Status = EProjectStatusEnum.Suspended;
        }

        public void Finish()
        {
            if (Status == EProjectStatusEnum.InProgress)
            {
                Status = EProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }      
        }

        public void Start()
        {
            if (Status == EProjectStatusEnum.Created || Status == EProjectStatusEnum.Suspended)
            {
                Status = EProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
