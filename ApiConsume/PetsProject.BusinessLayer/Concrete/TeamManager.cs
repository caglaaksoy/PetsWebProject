﻿using PetsProject.BusinessLayer.Abstract;
using PetsProject.DataAccessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void TDelete(Team t)
        {
            _teamDal.Insert(t);
        }

        public Team TGetByID(int id)
        {
           return _teamDal.GetByID(id);
        }

        public List<Team> TGetList()
        {
           return _teamDal.GetList();
        }

        public void TInsert(Team t)
        {
            _teamDal.Insert(t);
        }

        public void TUpdate(Team t)
        {
            _teamDal.Update(t);
        }
    }
}
