using CP_Messenger.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CP_Messenger.Controls
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }

        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var selectedTemplate = this.TextTemplate;

            var setting = item as Message;
            //if (setting == null) return selectedTemplate;

            switch (setting.Type)
            {
                case MessageType.Text:
                    selectedTemplate = this.TextTemplate;
                    break;
                case MessageType.Image:
                    selectedTemplate = this.ImageTemplate;
                    break;
                case MessageType.File:
                    selectedTemplate = this.FileTemplate;
                    break;

            }

            return selectedTemplate;
        }
    }
}
