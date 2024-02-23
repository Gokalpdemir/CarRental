
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarıyla eklendi";
        public static string Deleted = "Başarıyla Silindi";
        public static string Updated = "Başarıyla Güncellendi";
        public static string Listed = "Başarıyla Listelendi";
        public static string Error = "İşlem Başarısız";
        public static string CarIsNotAvailable="Araç Müsait Değil";
        public static string PasswordRequirements = "Şifreniz en az bir harf, bir rakam, bir özel karakter ve bir büyük harf içermeli ve toplamda en az 6 karakter uzunluğunda olmalıdır. ";
        public static string FirstNameMustContainOnlyLetter = "Ad yalnızca harflerden oluşmalıdır ";
        public static string LastNameMustContainOnlyLetter = "Soyad yalnızca harflerden oluşmalıdır ";
        public static string ColorNameMustContainOnlyLetter = "Renk ismi yalnızca harflerden oluşmalıdır.";
        public static string ImagesLimitExceeded = "Araç başına resim sayısı 5 ile sınırlıdır";
        public static string DefaultImage = "Araba resmi olmadığından default resim gösterilicektir";
        public static string UserNotFound = "kullanıcı kayıtlı değil";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessFulLogin = "sisteme giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten  mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string ClaimAlreadyExists = "Aynı ada sahip başka bir rol var";
        public static string OperationClaimNotFound = "Rol bulunamadı";
        public static string UserOperationClaimNotFound = "Kullanıcıya ait rol bulunamadı";
        public static string ValidateEmailNotEmpty = "Email alanı boş olamaz!";
        public static string ValidatePasswordNotEmpty = "Şifre alanı boş olamaz!";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz yok";
    }
}
