﻿using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.CancelProject
{
    public class CancelProjectCommand : IRequest<Unit>
    {
        public CancelProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
