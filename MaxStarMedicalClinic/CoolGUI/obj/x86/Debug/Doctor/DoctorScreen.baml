   M S B A M L   `   `   `  ����  CoolGUI    CoolGUI.DoctorScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   /   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6l   -   5          � Title$  DoctorScreen��5   	   $	��674��6�   $	��853��6�    � 
ResizeMode$ NoResize=�6�   .��5      � $	��630��6   $	��827��6   .+�5   
   �� -   5        $��label_doctor��5   [   $��Welcome��6   $��28��6"   $
��Left=�6.   $��12,7,0,0q�6I   $	��Top=�6p   $
��Bold"�6�   �� 5   
   -   5        $��data_doctor��5   \   $	��xxx��6   $��28��6   $��Stretch=�6*   $��
95,7,517,0q�6H   $	��Top=�6o   �� 5   
   -   5        $��label_patient��5   `   $��Patient ID:��6   $��28��6&   $
��Left=�62   $��	14,67,0,0q�6M   $	��Top=�6u   $
��Bold"�6�   �� 5	   
   -   5        $��data_patient��5	   L   $��23��6   $
��Left=�6   $��	95,70,0,0q�69   $	��Top=�6`   $	��120��6x   {�.  �� 
IsReadOnly .  6�   �� 5
   
   -   5        $��	go_button��5
   Y   $��Go��6   $��23��6   $
��Left=�6*   $��
230,70,0,0q�6E   $	��Top=�6j   $��41��6�   ���	#FF2FDAD7���	#FF2FDAD76�   �� 5   
   -   5        $
��logo��5   K   $	��173��6   $
��Left=�6   $��	590,5,0,0q�68   $��Uniform=�6W   $	��Top=�6i   $	��252��6�   $)��#/CoolGUI;component/Images/logo1.png��6�   �� 5   
   -   5        $��border1��5   s   
�������$��1q�6&   $��1��6:   $
��Left=�6E   $��	10,33,0,0q�6`   $	��Top=�6�   $	��407��6�   � 5   
   -	   5        $��	dataBlock��5      $y�Hidden=�6    $��Center=�64   $	��827��6Q   .+�5      �� -
   5        $��
label_name��5   _   $��Name:��6   $��28��6$   $
��Left=�60   $��
33,128,0,0q�6K   $	��Top=�6q   $
��Bold"�6�   �� 5      -   5        $��	data_name��5   ]   $	��xxx��6   $��28��6"   $
��Left=�6.   $��
84,128,0,0q�6I   $	��Top=�6n   �� 5      -   5        $��	label_age��5   _   $
��Age:��6   $��28��6#   $
��Left=�6/   $��212,128,0,0q�6J   $	��Top=�6p   $
��Bold"�6�   �� 5      -   5        $��data_age��5   ^   $	��xxx��6   $��28��6"   $
��Left=�6.   $��254,128,0,0q�6I   $	��Top=�6n   �� 5      -   5        $��label_gender��5   b   $��Gender:��6   $��28��6&   $
��Left=�62   $��337,128,0,0q�6M   $	��Top=�6v   $
��Bold"�6�   �� 5      -   5        $��data_gender��5   ^   $	��xxx��6   $��28��6"   $
��Left=�6.   $��398,128,0,0q�6I   $	��Top=�6q   �� 5      -   5        $��	prognosis��5   c   $��	Prognosis��6   $��28��6(   $
��Left=�64   $��
33,178,0,0q�6O   $	��Top=�6t   $
��Bold"�6�   �� 5      -   5        $��	data_prog��5   R   $	��131��6   $
��Left=�6#   $��
37,212,0,0q�6>   $	��Top=�6c   $	��472��6{    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . $��Disabled=�6�   $
��Auto=�5      �� 5      -   5        $��prescriptions��5   g   $��Prescriptions��6   $��28��6,   $
��Left=�68   $��
33,360,0,0q�6S   $	��Top=�6|   $
��Bold"�6�   �� 5      -   5        $��
data_presc��5   g    . $	��131��6+   $
��Left=�68   $��
37,394,0,0q�6S   $��Disabled=�6y   $
��Auto=�6�   $
 Wrap=�6�   $	��Top=�6�   $	��472��6  �� 5      -   5        $
��save��5   �   ���	#FF2FDAD7���	#FF2FDAD7$��Save & Continue��6D   $��52��6b   $��Right=�6n   $��0,556,318,0q�6�   $	��Top=�6�   $	��131��6�   $��Normal"�6�   �� 5      -   5        $��
treatments��5   �   ���#ee6557���#ee6557$��Previous Treatments��6A   $	��131��6_   $
��Left=�6l   $��564,212,0,0q�6�   $	��Top=�6�   $	��180��6�   
�������$��14(�6�   $��Normal"�6  �� 5      -   5        $��border2��5   �   $��1q�6    �� CornerRadius$ 4,4,4,4��6)   ���	#FFABADB3$	��131��6X   $
��Left=�6e   $��564,394,0,0q�6�   $	��Top=�6�   $	��180��6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��startDatePicker��5   I   $
��Left=�6   $��574,428,0,0q�64   $	��159��6`   $��Normal"�6l   $��25��6�   $	��Top=�6�     5      -   5        $��finishDatePicker��5   U   $��25��6   $
��Left=�6%   $��574,488,0,0q�6@   $	��Top=�6m   $	��159��6�   �� 5       -   5        $��label1��5    h   $��Date of Start��6   $��28��6,   $
��Left=�68   $��569,399,0,0q�6S   $	��Top=�6v   $
��Bold"�6�   �� 5!      -   5        $��label2��5!   i   $��Date of Finish��6   $��28��6-   $
��Left=�69   $��569,462,0,0q�6T   $	��Top=�6w   $
��Bold"�6�   5"      5$      5'      