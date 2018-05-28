﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.Database;
using WebAPI.Models.DTO;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Services
{
    public class ProposalService
    {
        private DBContextWebAPI context = new DBContextWebAPI();

        public List<ProposalDTO> Get()
        {
            var list = context.Proposals
                            .Join(
                                context.Categories,
                                proposal => proposal.IdCategory,
                                category => category.Id,
                                (proposal, category) => new { proposal, category }
                            )
                            .Join(
                                context.Suppliers,
                                join => join.proposal.IdSupplier,
                                supplier => supplier.Id,
                                (join, supplier) => new { join, supplier })
                            .AsEnumerable()
                            .Select(item => new ProposalDTO
                             {
                                 CategoryName = item.join.category.Name,
                                 Date = item.join.proposal.Date.ToString("dd/MM/yyyy"),
                                 Description = item.join.proposal.Description,
                                 Id = item.join.proposal.Id,
                                 IdCategory = item.join.proposal.IdCategory,
                                 IdSupplier = item.join.proposal.IdSupplier,
                                 Name = item.join.proposal.Name,
                                 NameFile = item.join.proposal.NameFile,
                                 StatusDescription = EnumDescription.GetDescription(item.join.proposal.Status),
                                 StatusNowDescription = EnumDescription.GetDescription(item.join.proposal.StatusNow),
                                 SupplierName = item.supplier.Name,
                                 Value = item.join.proposal.Value
                            }).ToList();

            return list;
        }

        public Proposal Get(decimal id)
        {
            return context.Proposals.Find(id);
        }

        internal int Post(Proposal proposal)
        {
            context.Proposals.Add(proposal);
            return context.SaveChanges();
        }

        internal int Delete(int id)
        {
            Proposal proposal = new Proposal { Id = id };
            context.Proposals.Attach(proposal);
            context.Proposals.Remove(proposal);
            return context.SaveChanges();
        }

        internal int Put(ProposalDTO proposal)
        {
            Proposal upd = context.Proposals.First(x => x.Id == proposal.Id.Value);
            int row = 0;

            if (upd != null)
            {
                upd.Description = proposal.Description;
                upd.IdCategory = proposal.IdCategory;
                upd.IdSupplier = proposal.IdSupplier;
                upd.Name = proposal.Name;
                upd.Value = proposal.Value;

                row = context.SaveChanges();
            }

            return row;
        }
    }
}