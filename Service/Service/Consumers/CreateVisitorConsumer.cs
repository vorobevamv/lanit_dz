using MassTransit;
using System.Threading.Tasks;


namespace Service
{
    public class CreateVisitorConsumer : IConsumer<Models.CreateVisitorRequest>
    {
        CreateVisitorRequestMapper mapreq = new();
        VisitorsRepository repository = new(new DatabaseContext());
        CreateVisitorResponseMapper mapres = new();

        public async Task Consume(ConsumeContext<Models.CreateVisitorRequest> context)  //Consume вызывается автоматически, когда приходит запрос; CreateVisitorRequest - тип запроса, context - экземпляр запроса (конкретный запрос)
        {

            DbVisitors visitor = mapreq.MapToDbVisitors(context.Message);
            var v = await repository.CreateVisitor(visitor);
            var response = mapres.MapToCreateVisitorResponse(v);
                                   
            await context.RespondAsync<Models.CreateVisitorResponse>(response);  //отправка ответа; CreateVisitorResponse - тип ответа, response - конкретный экземпляр ответа
        }
    }
}
