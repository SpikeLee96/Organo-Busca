namespace Organobusca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Avaliacao = new HashSet<Avaliacao>();
            Preferencia = new HashSet<Preferencia>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "por favor preencha o campo!")]
        [RegularExpression(@"^([\'\.\^\~\¥\`\\·¡\\‡¿\\„√\\‚¬\\È…\\Ë»\\Í \\ÌÕ\\ÏÃ\\Û”\\Ú“\\ı’\\Ù‘\\˙⁄\\˘Ÿ\\Á«aA-zZ]+)+((\s[\'\.\^\~\¥\`\\·¡\\‡¿\\„√\\‚¬\\È…\\Ë»\\Í \\ÌÕ\\ÏÃ\\Û”\\Ú“\\ı’\\Ù‘\\˙⁄\\˘Ÿ\\Á«aA-zZ]+)+)?", ErrorMessage = "Permitido somente letras mai˙sculas e min˙sculas!")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Requerido no mÌnimo 5 e no m·ximo 100 caracteres!")]

        public string nome { get; set; }

        [Required(ErrorMessage = "por favor preencha o campo!")]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inv·lido!")]
        public string email { get; set; }

        [Required(ErrorMessage = "por favor preencha o campo!")]
        [Display(Name = "Senha")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Requerido no mÌnimo 5 e no m·ximo 30 caracteres!")]
        public string senha { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "por favor preencha o campo!")]
        [Display(Name = "ConfirmaÁ„o de Senha")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Requerido no mÌnimo 5 e no m·ximo 30 caracteres!")]
        [Compare("senha", ErrorMessage = "senhas n„o batem!")]
        public string confirmaSenha { get; set; }

        [Display(Name = "Foto de perfil")]
        public string url_foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Preferencia> Preferencia { get; set; }
    }
}
