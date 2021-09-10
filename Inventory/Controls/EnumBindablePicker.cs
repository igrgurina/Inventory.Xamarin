using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Inventory.Controls
{
    class EnumBindablePicker<T> : Picker where T : struct
    {
        public EnumBindablePicker()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
            // fill the items from the enum
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Items.Add(value.ToString());
            }
        }

        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem),
                typeof(T),
                typeof(EnumBindablePicker<T>),
                default(T),
                propertyChanged: OnSelectedItemChanged,
                defaultBindingMode: BindingMode.TwoWay);

        public T SelectedItem
        {
            get => (T)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = default(T);
            }

            {
                SelectedItem = (T)Enum.Parse(typeof(T), Items[SelectedIndex]);
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as EnumBindablePicker<T>;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            }
        }
    }

    // BindableProperty.Create(nameof(SelectedItem),
    // typeof(T),
    // typeof(EnumBindablePicker<T>),
    // default(T),
    // propertyChanged: OnSelectedItemChanged,
    // defaultBindingMode: BindingMode.TwoWay);

}
