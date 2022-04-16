using MassTransit;
using System.Threading.Tasks;


namespace Service
{
    public class CreateVistorConsumer : IConsumer<Models.CreateVistorRequest>
    {
        CreateVisitorRequestMapper mapreq;
        VisitorsRepository repository;
        CreateVisitorResponseMapper mapres;

        public async Task Consume(ConsumeContext<Models.CreateVistorRequest> context)  //Consume вызывается автоматически, когда приходит запрос; CreateVistorRequest - тип запроса, context - экземпляр запроса (конкретный запрос)
        {


            DbVisitors visitor = mapreq.MapToDbVisitors((Models.CreateVistorRequest)context);
            var v = await repository.CreateVisitor(visitor);
            var response = mapres.MapToCreateVisitorResponse(v);
                                   
            await context.RespondAsync<Models.CreateVisitorResponse>(response);  //отправка ответа; CreateVisitorResponse - тип ответа, response - конкретный экземпляр ответа
        }
    }
}
