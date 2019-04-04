This class library create a random name out of the 100 most common female first names and the 100 most common male first names in the USA.
The last names are based on the 100 most common last names in the USA.

Randomizations are made through RNGCryptoServiceProvider to decide the gender and to create the seed for the regular Random class.

Move the file names.xlsx to your executing directory that use the class library.

Add the project as a reference.

Call "NameGenerator.NameGenerator.GetFirstName()" to get a first name, will randomize the gender.
Call "NameGenerator.NameGenerator.GetLastName()" to get a last name.

Usage example (will get 10 random first and last names):

for(int i = 0; i < 10; i++)
{
	string firstName = NameGenerator.NameGenerator.GetFirstName();
	string lastName = NameGenerator.NameGenerator.GetLastName().;
}

Result example (lastName, firstName):
--Run 1--
Lewis, Michelle
Carter, Rebecca
Morris, Douglas
Roberts, Sean
Coleman, Justin
Morgan, Rebecca
Thomas, Russell
Davis, Ethan
Jenkins, Olivia
Miller, Russell

--Run 2--
Hill, James
Howard, Peter
Butler, Lawrence
Lewis, Catherine
Gonzalez, Lori
Ross, Emma
Perez, Alice
Martinez, Debra
Watson, Brandon
Wilson, Betty