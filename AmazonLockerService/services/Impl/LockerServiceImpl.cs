using AmazonLockerService.models;
using AmazonLockerService.repository;
using AmazonLockerService.repository.inMemory;
using AmazonLockerService.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.services.Impl
{
    public class LockerServiceImpl : ILockerService
    {
        private readonly ILockerRepository _lockerRepository = LockerRepositoryInMemory.Instance;
        public Locker AddLocker(string lockerId, Location location)
        {
            var locker = new Locker(lockerId, location);
            return _lockerRepository.Add(lockerId, locker);
        }

        public Locker FindNearByLocker(Location location)
        {
            var lockerByDistance = _lockerRepository
                .DbSet
                .Values
                .Select(x => new
                {
                    locker = x,
                    dist = LocationUtil.GetDistance(location, x.Location)
                })
                .ToList();
                
            lockerByDistance.Sort((a,b) => a.dist.CompareTo(b.dist));
            return lockerByDistance.First()?.locker;
        }
    }
}
