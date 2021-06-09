#include <iostream>
using namespace std;

int FlHouseID = 1;
int PrHouseID = 52;
int GHouseID = 12;
enum Blocks
{
	Brick, FoamBlock, Ceramic, GasSilicate, SlagСoncrete, FoamConcrete, ExpandedClay, Polymer, Wood
};

class Property
{
protected:
	float cost;

public:

	float GetCost()
	{
		return cost;
	}

	virtual void SetCost() = 0;

	virtual void GetData() = 0;
};

class Land //: public Property
{

};

class House : public Property
{
protected:
	float a; float b; float h;
	bool IsFinished;
	Blocks blocks;
	Land land;
public:
	virtual float Volume() = 0;
	
};

class FloorHouse : public House
{
private:
	bool UndergroundGarage;
	bool MultifuncGF;
	int floors;
	float s;
	int id;  //ID документа
public:
	FloorHouse()
	{
		IsFinished = false;
		UndergroundGarage = false;
		MultifuncGF = false;
		a = 100;
		b = 61.5f;
		h = 27;
		floors = 9;
		blocks = Brick;
		id = ++FlHouseID;
		s = 0.5f;
	}
	FloorHouse(bool finished, bool UndGarage, bool MultifuncGF, float a, float b, float h, int floors, Blocks bl, Land &land, float s)
	{
		IsFinished = finished;
		UndergroundGarage = UndGarage;
		this->MultifuncGF = MultifuncGF;
		this->a = a; this->b = b; this->h = h;
		this->floors = floors;
		blocks = bl;
		this->land = land;
		id = ++FlHouseID;
		this->s = s;
	}

	float Volume() override
	{
		
		return a * b * h;

	}

	void SetCost() override
	{
		
	}

	void changeState(bool finished)
	{
		IsFinished = finished;
	}

	float FloorHeight()
	{
		return ((h - floors * s) / floors);
	}

	void GetData() override
	{
		cout << "Состояние строительства: " << IsFinished << endl;
		cout << "Подземный гараж: " << UndergroundGarage << endl;
		cout << "Многофункциональный первый этаж: " << MultifuncGF << endl;
		cout << "Кол-во этажей " << floors << endl;
		cout << "Построен из: " << blocks << endl;
	}
};


class PrivateHouse : public House
{
private:
	int floors;
	float s;
	int id;
	float roofV;
	
public:
	PrivateHouse()
	{
		a = 20;
		b = 7.5;
		h = 12;
		IsFinished = false;
		blocks = Wood;
		roofV = 225;
		id = ++PrHouseID;
	}

	PrivateHouse(float a, float b, float h, bool finished, int floors, Blocks bl, Land& land, float s, float roofV)
	{
		this->a = a; this->b = b; this->h = h; 
		IsFinished = finished;
		this->floors = floors;
		blocks = bl;
		this->land = land;
		this->s = s;
		this->roofV = roofV;
	}
	
	float Volume() override
	{
		return (a * b * h + roofV);
	}

	void SetCost() override
	{

	}

	void GetData() override
	{
		
	}
};

class Part : public PrivateHouse
{
public:
	Part()
	{
		a = 40;
		b = 25;
		h = 10;
		IsFinished = false;
		blocks = Wood;
	}

	Part(float a, float b, float h, bool fin, Blocks bl)
	{
		this->a = a; this->b = b; this->h = h;
		IsFinished = fin;
		blocks = bl;
	}

	float Volume() override
	{
		return a * b * h;
	}

	void GetData() override
	{
		cout << 'f';
	}

	void SetCost() override
	{
		cout << "f";
	}
};


class GardenHouse : public House
{

};

class NonResidential : public Property
{

};

class Garage : public NonResidential
{

};

class Warehouse : public NonResidential
{

};

class Shop : public NonResidential
{

};

class Bank : public NonResidential
{

};

class Basement : public NonResidential
{

};

class Barn : public NonResidential
{

};

class Coop : public NonResidential
{

};



int main()
{
	PrivateHouse pr;
	pr.GetData();
	return 0;
}