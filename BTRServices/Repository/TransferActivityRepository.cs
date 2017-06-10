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
    public class TransferActivityRepository : Repository<TransferActivityDTO>
    {
        public TransferActivityRepository(BtrDbContext context) : base(context)
        {
        }

        internal TransferActivityDTO Item(int id)
        {
            return (from a in _context.vw_transfer_activities_datarecords
                    where a.transfer_activity_key == id
                    select new TransferActivityDTO
                    {
                        transfer_activity_key = a.transfer_activity_key,
                        btr_key = a.btr_key,
                        position_type_key = a.position_type_key,
                        position_type = a.position_type,
                        index_key = a.index_key,
                        index_number_description = a.index_number_description,
                        account_key = a.account_key,
                        account_number_description = a.account_number_description,
                        amount = a.amount,
                        jv_doc_id = a.jv_doc_id,
                        jv_complete = a.jv_complete,
                        complete_jv_status_message = a.complete_jv_status_message,
                        create_jv_error_message = a.create_jv_error_message,
                        created = a.created,
                        created_by = a.created_by,
                        created_email = a.created_email,
                        modified = a.modified,
                        modified_by = a.modified_by,
                        modified_email = a.modified_email
                    }
                    ).FirstOrDefault();
        }

        public IEnumerable<TransferActivityDTO> ItemsByBtrId(int btr_key)
        {
            return (from a in _context.vw_transfer_activities_datarecords
                    where a.btr_key == btr_key
                    select new TransferActivityDTO
                    {
                        transfer_activity_key = a.transfer_activity_key,
                        btr_key = a.btr_key,
                        position_type_key = a.position_type_key,
                        position_type = a.position_type,
                        index_key = a.index_key,
                        index_number_description = a.index_number_description,
                        account_key = a.account_key,
                        account_number_description = a.account_number_description,
                        amount = a.amount,
                        jv_doc_id = a.jv_doc_id,
                        jv_complete = a.jv_complete,
                        complete_jv_status_message = a.complete_jv_status_message,
                        create_jv_error_message = a.create_jv_error_message,
                        created = a.created,
                        created_by = a.created_by,
                        created_email = a.created_email,
                        modified = a.modified,
                        modified_by = a.modified_by,
                        modified_email = a.modified_email
                    }
                    ).ToList();
        }

        public IEnumerable<TransferActivityDTO> Items()
        {
            return (from a in _context.vw_transfer_activities_datarecords
                    select new TransferActivityDTO
                    {
                        transfer_activity_key = a.transfer_activity_key,
                        btr_key = a.btr_key,
                        position_type_key = a.position_type_key,
                        position_type = a.position_type,
                        index_key = a.index_key,
                        index_number_description = a.index_number_description,
                        account_key = a.account_key,
                        account_number_description = a.account_number_description,
                        amount = a.amount,
                        jv_doc_id = a.jv_doc_id,
                        jv_complete = a.jv_complete,
                        complete_jv_status_message = a.complete_jv_status_message,
                        create_jv_error_message = a.create_jv_error_message,
                        created = a.created,
                        created_by = a.created_by,
                        created_email = a.created_email,
                        modified = a.modified,
                        modified_by = a.modified_by,
                        modified_email = a.modified_email
                    }
                    ).ToList();

        }


        public IEnumerable<BtrDTO> ByUni(int requestor_uni_key)
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

        public TransferActivityDTO Create(TransferActivityDTO item)
        {
            ObjectResult<transfer_activity_create_Result> spData = _context.transfer_activity_create(item.btr_key, item.position_type_key, item.index_key, item.account_key, item.amount, item.created_by);
            transfer_activity_create_Result result = spData.First<transfer_activity_create_Result>();
            TransferActivityDTO transferdto = new TransferActivityDTO
            {
                transfer_activity_key = result.transfer_activity_key,
                btr_key = result.btr_key,
                position_type_key = result.position_type_key,
                position_type = result.position_type,
                index_key = result.index_key,
                index_number_description = result.index_number_description,
                account_key = result.account_key,
                account_number_description = result.account_number_description,
                amount = result.amount,
                jv_doc_id = result.jv_doc_id,
                jv_complete = result.jv_complete,
                complete_jv_status_message = result.complete_jv_status_message,
                create_jv_error_message = result.create_jv_error_message,
                created = result.created,
                created_by = result.created_by,
                created_email = result.created_email,
                modified = result.modified,
                modified_by = result.modified_by,
                modified_email = result.modified_email
            };

            return transferdto;
        }
        public TransferActivityDTO Update(TransferActivityDTO item)
        {
            ObjectResult<transfer_activity_update_Result> data = _context.transfer_activity_update(item.transfer_activity_key, item.index_key, item.account_key, item.amount, item.modified_by);
            transfer_activity_update_Result result = data.FirstOrDefault<transfer_activity_update_Result>();
            TransferActivityDTO transferdto = new TransferActivityDTO
            {
                transfer_activity_key = result.transfer_activity_key,
                btr_key = result.btr_key,
                position_type_key = result.position_type_key,
                position_type = result.position_type,
                index_key = result.index_key,
                index_number_description = result.index_number_description,
                account_key = result.account_key,
                account_number_description = result.account_number_description,
                amount = result.amount,
                jv_doc_id = result.jv_doc_id,
                jv_complete = result.jv_complete,
                complete_jv_status_message = result.complete_jv_status_message,
                create_jv_error_message = result.create_jv_error_message,
                created = result.created,
                created_by = result.created_by,
                created_email = result.created_email,
                modified = result.modified,
                modified_by = result.modified_by,
                modified_email = result.modified_email
            };

            return transferdto;

        }

        public void Delete(int transfer_activity_key)
        {
            _context.transfer_activity_delete(transfer_activity_key);
        }
    }
}