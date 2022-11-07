﻿using ErrorOr;
using MediatR;
using CyberTutorial.Application.Documents.Common;

namespace CyberTutorial.Application.Documents.Queries
{
    public class DownloadDocumentQuery : IRequest<ErrorOr<DownloadDocumentResult>>
    {
        public string DocumentId { get; set; }
    }
}