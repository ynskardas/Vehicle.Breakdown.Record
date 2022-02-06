﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Concretes
{
    public class VehicleRepository : IBaseInterface<Vehicle>, IVehicleRepository
    {
        public Vehicle Add(Vehicle entity)
        {
            using (var context = new VehicleDbContext())
            {
                context.Vehicles.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var context = new VehicleDbContext())
            {
                context.Vehicles.Remove(GetByID(id));
                context.SaveChanges();
            }
        }

        public List<Vehicle> GetAll()
        {
            using (var context = new VehicleDbContext())
            {
                return context.Vehicles.ToList();
            }
        }

        public Vehicle GetByID(int id)
        {
            using (var context = new VehicleDbContext())
            {
                return context.Vehicles.Find(id);
            }
        }

        public Vehicle Update(Vehicle entity)
        {
            using (var context = new VehicleDbContext())
            {
                context.Vehicles.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public List<Vehicle> VehicleWithBreakdownListAndComment()
        {
            using (var context = new VehicleDbContext())
            {
                //return context.Vehicles.Include("BreakdownLists").Include("VehicleComments").ToList();
                return context.Vehicles.Include(y => y.VehicleComments).Include(x => x.VehicleBreakdownLists).ThenInclude(x=>x.BreakdownList).ToList();
            }
        }

        //public List<Vehicle> VehicleWithComment()
        //{
        //    using (var context = new VehicleDbContext())
        //    {
        //        return context.Vehicles.Include(x=>x.VehicleComments).ToList();
        //    }
        //}
    }
}
