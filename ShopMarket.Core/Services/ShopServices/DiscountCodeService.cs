using System;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.Interfaces.ShopInterfaces;

namespace ShopMarket.Core.Services.ShopServices
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public DiscountCodeService(IDiscountCodeRepository discountCodeRepository)
        {
            _discountCodeRepository = discountCodeRepository;
        }

        public OperationResult DeleteCode(DiscountCode code)
        {
            try
            {
                if (code == null)
                    return OperationResult.NotFound();
                _discountCodeRepository.DeleteCode(code);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> DeleteCode(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _discountCodeRepository.DeleteCode(await GetCode(id));
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<bool> DoesCodeExist(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }
            return await _discountCodeRepository.DoesCodeExist(code);
        }

        public IQueryable<DiscountCode> GetAll()
        {
            return _discountCodeRepository.GetAll();
        }

        public Task<DiscountCode> GetCode(int id)
        {
            try
            {
                if (id == null)
                    return null;
                return _discountCodeRepository.GetCode(id);
            }
            catch
            {
                return null;
            }
        }

        public Task<DiscountCode> GetCode(string code)
        {
            return _discountCodeRepository.GetCode(code);
        }

        public async Task<DiscountCode> InsertCode(DiscountCode code)
        {
            try
            {
                if (code == null)
                    return null;
                if (string.IsNullOrEmpty(code.Code))
                {
                    string generatedCode = "";

                    do
                    {
                        generatedCode = Generators.GetRandomCode(6);

                    } while (await DoesCodeExist(generatedCode));

                    code.Code = generatedCode;
                }
                
                _discountCodeRepository.InsertCode(code);
                return code;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> IsCodeExpired(string code)
        {
            var discountCode = await _discountCodeRepository.GetCode(code);
            bool isExpired =
                discountCode.ExpireTime.Year <= DateTime.Now.Year &&
                discountCode.ExpireTime.Month <= DateTime.Now.Month &&
                discountCode.ExpireTime.Day <= DateTime.Now.Day;
            return isExpired;
        }

        public async Task<bool> IsCodeUsed(string code)
        {
            var discountCode = await _discountCodeRepository.GetCode(code);

            return discountCode.IsUsed;
        }
        
        public OperationResult UpdateCode(DiscountCode code)
        {
            try
            {
                if (code == null)
                    return OperationResult.NotFound();
                _discountCodeRepository.UpdateCode(code);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> UseDiscountCode(string code)
        {
            try
            {
                if (!await DoesCodeExist(code))
                    return OperationResult.NotFound();
                if(await IsCodeUsed(code) && await IsCodeExpired(code))
                    return OperationResult.Error("اعتبار این کد تخفیف به پایان رسیده است");
                DiscountCode discountCode = await GetCode(code);
                if (discountCode.CodeCount > 1)
                    discountCode.CodeCount--;
                else
                    discountCode.IsUsed = true;
                UpdateCode(discountCode);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}