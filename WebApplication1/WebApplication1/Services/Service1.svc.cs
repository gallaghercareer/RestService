using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WebApplication1
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1

    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<SuperHero> getAllHeroes()
        {
            return Data.SuperHeroes;
        }

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json,UriTemplate ="getHero/{id}")]
        public SuperHero getHero(string id) { 
    
            return Data.SuperHeroes.Find(sh => sh.Id == int.Parse(id));
        }

        [OperationContract]
        [WebInvoke (ResponseFormat = WebMessageFormat.Json, BodyStyle =WebMessageBodyStyle.Bare, 
            UriTemplate ="addHero", Method = "POST")]
        public SuperHero addHero(SuperHero hero)
        {
            hero.Id = Data.SuperHeroes.Max(sh => sh.Id) + 1;
            Data.SuperHeroes.Add(hero);
            return hero;

            
        }
        // Add more operations here and mark them with [OperationContract]

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "UpdateHero/{id}", Method = "PUT")]

        public SuperHero UpdateHero(SuperHero updatedHero, string id)
        {
            SuperHero hero = Data.SuperHeroes.Where(sh => sh.Id == int.Parse(id)).FirstOrDefault();

            hero.FirstName = updatedHero.FirstName;
            hero.LastName = updatedHero.LastName;
            hero.HeroName = updatedHero.HeroName;
            hero.PlaceOfBirth = updatedHero.PlaceOfBirth;
            hero.Combat = updatedHero.Combat;

            return hero;
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "DeleteHero/{id}", Method = "DELETE")]
        public List<SuperHero> DeleteHero(string id)
        {
            Data.SuperHeroes = Data.SuperHeroes.Where(sh => sh.Id != int.Parse(id)).ToList();
            return Data.SuperHeroes;
        }
    }

}
