﻿using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}