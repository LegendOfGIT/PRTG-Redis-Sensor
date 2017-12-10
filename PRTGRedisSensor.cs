using StackExchange.Redis;
using System.Linq;
using System.Net;

namespace PRTG_Redis_Sensor
{
  public class PRTGRedisSensor
  {
    public string RedisConnectionString { get; set; }

    public PRTGResponse GetSensorInformation()
    {
      if (string.IsNullOrEmpty(this.RedisConnectionString))
      {
        return new PRTGResponse {
          ErrorMessage = "No redis connection string is given"
        };
      }

      var redisConnectionOptions = ConfigurationOptions.Parse(this.RedisConnectionString);
      var redis = ConnectionMultiplexer.Connect(this.RedisConnectionString);
      var endpoint = redisConnectionOptions.EndPoints.First() as DnsEndPoint;
      var databaseId = endpoint.Host;
      var server = redis.GetServer(endpoint);

      return null;
    }
  }
}
