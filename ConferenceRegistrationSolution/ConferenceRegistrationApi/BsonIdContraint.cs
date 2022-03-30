﻿using MongoDB.Bson;

namespace ConferenceRegistrationApi;

public class BsonIdContraint : IRouteConstraint
{
    // "products/{id:bsonid}"
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
       if(values.TryGetValue(routeKey, out var routeValue))
        {
            var parameterValue = Convert.ToString(routeValue);
            if(ObjectId.TryParse(parameterValue, out var _))
            {
                return true;
            } else
            {
                return false;
            }
        }
        return false;
    }
}
