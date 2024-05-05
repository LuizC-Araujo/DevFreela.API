﻿using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}