using BTRServices.DAL;
using BTRServices.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BTRServices.Repository
{
    public class BTRRepository : Repository<BtrDTO>
    {
        public BTRRepository(BtrDbContext context) : base(context)
        {
        }

        internal BtrDTO Item(int id)
        {
            return (from a in _context.budget_transfer_request_datarecord(id)
                    select new BtrDTO
                    {
                        btr_key = a.btr_key,
                        btr_guid = a.btr_guid,
                        title = a.title,
                        budget_type = a.budget_type,
                        explanation = a.explanation,
                        life_cycle = a.life_cycle,
                        priority_flag = a.priority_flag,
                        requestor_uni_code = a.request_uni_code,
                        total_amount = a.total_amount,
                        requestor_uni_key = a.requestor_uni_key,
                        transfer_type_key = a.transfer_type_key.Value,
                        transfer_type = a.transfer_type,
                        internal_state = a.internal_state,
                        internal_state_key = a.internal_state_key,
                        modified = a.modified,
                        created = a.created,
                        modified_by = a.modified_by,
                        created_by = a.created_by,
                        created_by_name = a.created_by_name,
                        modified_by_name = a.modified_by_name
                    }).FirstOrDefault();
       }

        internal IEnumerable<BtrDTO> Items()
        {
            return (from a in _context.budget_transfer_request_datarecords()
                    select new BtrDTO
                    {
                        btr_key = a.btr_key,
                        btr_guid = a.btr_guid,
                        title = a.title,
                        budget_type = a.budget_type,
                        explanation = a.explanation,
                        life_cycle = a.life_cycle,
                        priority_flag = a.priority_flag,
                        requestor_uni_code = a.request_uni_code,
                        total_amount = a.total_amount,
                        requestor_uni_key = a.requestor_uni_key,
                        transfer_type_key = a.transfer_type_key.Value,
                        transfer_type = a.transfer_type,
                        internal_state = a.internal_state,
                        modified = a.modified,
                        created = a.created,
                        modified_by = a.modified_by,
                        created_by = a.created_by,
                        created_by_name = a.created_by_name,
                        modified_by_name = a.modified_by_name
                    }).ToList();
        }

        internal IEnumerable<BtrDTO> ByUni(int requestor_uni_key)
        {
            
            return (from a in _context.vw_budget_transfer_request_records
                    where a.requestor_uni_key == requestor_uni_key
                    select new BtrDTO
                    {
                        btr_key = a.btr_key,
                        btr_guid = a.btr_guid,
                        title = a.title,
                        budget_type = a.budget_type,
                        explanation = a.explanation,
                        life_cycle = a.life_cycle,
                        priority_flag = a.priority_flag,
                        requestor_uni_code = a.request_uni_code,
                        total_amount = a.total_amount,
                        requestor_uni_key = a.requestor_uni_key,
                        transfer_type_key = a.transfer_type_key.Value,
                        transfer_type = a.transfer_type,
                        internal_state = a.internal_state,
                        modified = a.modified,
                        created = a.created,
                        modified_by = a.modified_by,
                        created_by = a.created_by,
                        created_by_name = a.created_by_name,
                        modified_by_name = a.modified_by_name
                    }).ToList();
        }

        internal BtrDTO Create(BtrDTO btrItem)
        {
            ObjectResult<budget_transfer_request_create_Result> spData = _context.budget_transfer_request_create(btrItem.title, btrItem.budget_type, btrItem.total_amount, btrItem.explanation, btrItem.requestor_uni_code, btrItem.transfer_type, btrItem.created_by_name);
            budget_transfer_request_create_Result result = spData.First<budget_transfer_request_create_Result>();
            BtrDTO btrResult = new BtrDTO
            {
                btr_key = result.btr_key,
                btr_guid = result.btr_guid,
                title = result.title,
                budget_type = result.budget_type,
                explanation = result.explanation,
                life_cycle = result.life_cycle,
                priority_flag = result.priority_flag,
                requestor_uni_code = result.request_uni_code,
                total_amount = result.total_amount,
                requestor_uni_key = result.requestor_uni_key,
                transfer_type_key = result.transfer_type_key.Value,
                transfer_type = result.transfer_type,
                internal_state = result.internal_state,
                modified = result.modified,
                created = result.created,
                modified_by = result.modified_by,
                created_by = result.created_by,
                created_by_name = result.created_by_name,
                modified_by_name = result.modified_by_name
            };
            return btrResult;
        }

        internal BtrDTO Update(BtrDTO btrItem)
        {
            ObjectResult<budget_transfer_request_update_Result> spData = _context.budget_transfer_request_update(btrItem.btr_key,btrItem.title, btrItem.budget_type_key, btrItem.total_amount, btrItem.explanation, btrItem.requestor_uni_key, btrItem.transfer_type_key,btrItem.life_cycle_key, btrItem.modified_by);
            budget_transfer_request_update_Result result = spData.First<budget_transfer_request_update_Result>();
            BtrDTO btrResult = new BtrDTO
            {
                btr_key = result.btr_key,
                btr_guid = result.btr_guid,
                title = result.title,
                budget_type = result.budget_type,
                explanation = result.explanation,
                life_cycle = result.life_cycle,
                life_cycle_key = result.life_cycle_key,
                priority_flag = result.priority_flag,
                requestor_uni_code = result.request_uni_code,
                total_amount = result.total_amount,
                requestor_uni_key = result.requestor_uni_key,
                transfer_type_key = result.transfer_type_key.Value,
                transfer_type = result.transfer_type,
                internal_state = result.internal_state,
                modified = result.modified,
                created = result.created,
                modified_by = result.modified_by,
                created_by = result.created_by,
                created_by_name = result.created_by_name,
                modified_by_name = result.modified_by_name
            };
            return btrResult;
        }

        internal void Delete(budget_transfer_request btrRecord)
        {
            _context.budget_transfer_request.Remove(btrRecord);
        }
    }
}