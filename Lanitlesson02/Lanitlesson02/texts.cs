
/*
 * 
 * 
 *  [HttpPost("createvisitor")]
        public List<string> createvisitor(
            [FromServices] IValidator<CreateVisitorRequest> validator,
            [FromBody] CreateVisitorRequest request)
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)                               //IsValid - no errors; !xxx.IsValid - errors
            {
                return validationResult.Errors.Select(x => x.ErrorMessage).ToList();              //из массива Errors (сформировался автоматически) выбираем сообщения
            }
            return new List<string>() {"validation passed"};
            
        }
 * _________________________________________________
 * 
 *
public class ClubReq
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string OwnerName { get; set; }
}


public class CluVisReq
{
    public string ClubName { get; set; }
    public string VisName { get; set; }
}

_________________________________________________________________

[ApiController]
    [Route("[controller]")]
    public class InterestController : ControllerBase
    {
        [HttpPost("newowner")]
        public void newowner([FromBody] DbOwners request)
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                DbOwners owner = new DbOwners();
                owner.ID = Guid.NewGuid();
                owner.Name = request.Name;
                owner.Country = request.Country;
                con.Owners.Add(owner);  

                con.SaveChanges();
            }
        }
        [HttpPost("newvisitor")]
        public void newvisitor([FromBody] DbVisitors request)
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                DbVisitors visitor = new DbVisitors();
                visitor.ID = Guid.NewGuid();
                visitor.Name = request.Name;
                visitor.Age = request.Age;
                con.Visitors.Add(visitor);

                con.SaveChanges();
            }
        }
        [HttpPost("newclub")]
        public void newvisitor([FromBody] ClubReq request)
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                DbClubs club = new DbClubs();
                club.ID = Guid.NewGuid();
                club.Name = request.Name;
                club.Adress = request.Adress;
                club.OwnerID = (con.Owners.Where(x => x.Name == request.OwnerName).FirstOrDefault()).ID;
                con.Clubs.Add(club);

                con.SaveChanges();
            }
        }
        [HttpPost("newclubvis")]
        public void newclubvis([FromBody] CluVisReq request)
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                DbClubsVisitors clubvisit = new DbClubsVisitors();
                clubvisit.ID = Guid.NewGuid();
                clubvisit.ClubID = (con.Clubs.Where(x => x.Name == request.ClubName).FirstOrDefault()).ID;
                clubvisit.VisitorID = (con.Visitors.Where(x => x.Name == request.VisName).FirstOrDefault()).ID;
                con.ClubsVisitors.Add(clubvisit);

                con.SaveChanges();
            }
        }




*/