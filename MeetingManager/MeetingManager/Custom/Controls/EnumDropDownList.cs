using System;
using Xamarin.Forms;

namespace MeetingManager.Custom.Controls
{
    public class EnumDropDownList<T> : Picker 
        where T : struct
    {
        public EnumDropDownList()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Items.Add(value.ToString());
            }
        }

        public static new BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(T), typeof(EnumDropDownList<T>), default(T), propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public new T SelectedItem
        {
            get
            {
                return (T)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = default(T);
            }
            else
            {
                SelectedItem = (T)Enum.Parse(typeof(T), Items[SelectedIndex]);
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as EnumDropDownList<T>;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            }
        }
    }
}
