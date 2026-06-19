using Application.Curriculum.Subjects;
using Application.Curriculum.Subjects.CreateSubject;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api;

public static class SubjectEndpoints
{
    public static RouteGroupBuilder MapSubjectEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/curriculum/subjects")
            .WithTags("Curriculum Subjects");

        group.MapPost("/", CreateSubject)
            .WithName("CreateSubject")
            .Produces<CreateSubjectResult>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status409Conflict);

        return group;
    }

    private static async Task<Results<Created<CreateSubjectResult>, ValidationProblem, Conflict<string>>> CreateSubject(
        CreateSubjectRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new CreateSubjectCommand(
            request.Name,
            request.Description,
            request.GradeBand);

        var result = await sender.Send(command, cancellationToken);

        return TypedResults.Created(
            $"/api/curriculum/subjects/{result.Id}",
            result);
    }
}