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
    }
}
