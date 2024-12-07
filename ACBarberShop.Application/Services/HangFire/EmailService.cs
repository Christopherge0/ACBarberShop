using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Infraestructure.Data;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ACBarberShop.Application.Services.Implemetations
{
    public class EmailService
    {
        private readonly IRepositoryCita _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public EmailService(IRepositoryCita repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public  void SendEmail()
        {
            var list =  _repository.ListFechaInvestigacionUsuario();
            var collection = _mapper.Map<ICollection<CitaDTO>>(list);

            foreach (var Hola  in collection)
            {
                string toEmail = Hola.IdClienteNavigation.CorreoElectronico;
                string subject = "Recordatorio de tu cita en ACBarberShop";
                string message = $"Hola {Hola.IdClienteNavigation.Nombre},\n\n" +
                                 "Esperamos que estés teniendo un excelente día.\n\n" +
                                 "Te recordamos que tienes una cita programada para mañana a las " +
                                 $"{Hola.HoraInicio} en nuestra sucursal {Hola.IdSucursalNavigation.Nombre}.\n\n" +
                                 "Si necesitas reprogramar o cancelar tu cita, por favor contáctanos con anticipación.\n\n" +
                                 "Gracias por elegir ACBarberShop. ¡Esperamos verte pronto!\n\n" +
                                 "Saludos cordiales,\n" +
                                 "El equipo de ACBarberShop";


                var fromEmail = _configuration["EmailSettings:FromEmail"];
                var fromPassword = _configuration["EmailSettings:FromPassword"];
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);

                var smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);
            }

        
        
        }
    }
}
