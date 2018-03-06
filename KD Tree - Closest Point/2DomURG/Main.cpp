#include <iostream>
#include <stdlib.h>

struct Point
	{
		float x;
		float y;
	};
struct Elem
	{
		Point p;
		Elem* s1;
		Elem* s2;
		Elem* s3;
		Elem* s4;
	};
Point* niz;
int n;
Elem* gradnjaDrevesa(float x1, float x2, float y1, float y2, int gl)
{
	Elem* koren=new Elem;
	if (gl==1) 
	{
		koren->p.x=(x1+x2)/2; koren->p.y=(y1+y2)/2;
		koren->s1=new Elem;
		koren->s1->p.x=(x1+3*x2)/2; koren->s1->p.y=(y1+3*y2)/2;
		koren->s2=new Elem;
		koren->s2->p.x=(3*x1+x2)/2; koren->s2->p.y=(y1+3*y2)/2;
		koren->s3=new Elem;
		koren->s3->p.x=(3*x1+x2)/2; koren->s3->p.y=(3*y1+y2)/2;
		koren->s4=new Elem;
		koren->s4->p.x=(x1+3*x2)/2; koren->s4->p.y=(3*y1+y2)/2;
		koren->s1->s1=NULL; koren->s1->s2=NULL; koren->s1->s3=NULL; koren->s1->s4=NULL;
		koren->s2->s1=NULL; koren->s2->s2=NULL; koren->s2->s3=NULL; koren->s2->s4=NULL;
		koren->s3->s1=NULL; koren->s3->s2=NULL; koren->s3->s3=NULL; koren->s3->s4=NULL;
		koren->s4->s1=NULL; koren->s4->s2=NULL; koren->s4->s3=NULL; koren->s4->s4=NULL;
		return koren;
	}
	else 
	{
		koren->p.x=(x1+x2)/2; koren->p.y=(y1+y2)/2;
		koren->s1=new Elem;
		koren->s1=gradnjaDrevesa((x1+x2)/2, x2, (y1+y2)/2, y2, gl-1);
		koren->s2=new Elem;
		koren->s2=gradnjaDrevesa(x1, (x1+x2)/2, (y1+y2)/2, y2, gl-1);
		koren->s3=new Elem;
		koren->s3=gradnjaDrevesa(x1, (x1+x2)/2, y1, (y1+y2)/2, gl-1);
		koren->s4=new Elem;
		koren->s4=gradnjaDrevesa((x1+x2)/2, x2, y1, (y1+y2)/2, gl-1);
		return koren;
	}
}

void ispitajTocke(Elem* koren, int iCentar, float maxDist, int gl, float x1, float x2, float y1, float y2)
{
	if (sqrt((koren->p.x-niz[iCentar].x)*(koren->p.x-niz[iCentar].x)+(koren->p.y-niz[iCentar].y)*(koren->p.y-niz[iCentar].y))<=(maxDist+0.001))
	{
		if (sqrt((x1-niz[iCentar].x)*(x1-niz[iCentar].x)+(y1-niz[iCentar].y)*(y1-niz[iCentar].y))<=(maxDist+0.001))
		{
			if (sqrt((x2-niz[iCentar].x)*(x2-niz[iCentar].x)+(y2-niz[iCentar].y)*(y2-niz[iCentar].y))<=(maxDist+0.001))
			{
				if (sqrt((x1-niz[iCentar].x)*(x1-niz[iCentar].x)+(y2-niz[iCentar].y)*(y2-niz[iCentar].y))<=(maxDist+0.001))
				{
					if (sqrt((x2-niz[iCentar].x)*(x2-niz[iCentar].x)+(y1-niz[iCentar].y)*(y1-niz[iCentar].y))<=(maxDist+0.001))
					{
						for (int i=0; i<n; i++)
						{
							if (i!=iCentar)
							{
								if (niz[i].x>=x1 && niz[i].x<=x2 && niz[i].y>=y1 && niz[i].y<=y2) 
									printf("%d ", i);
							}
						}
					}
					return;
				}
			}
		}
	}
	if (gl==0) 
	{
		int b=0;
		if (((niz[iCentar].x+maxDist)<=x2) && ((niz[iCentar].x+maxDist)>=x1)) {b=1;}
		if (((niz[iCentar].x-maxDist)<=x2) && ((niz[iCentar].x-maxDist)>=x1)) {b=1;}
		if (((niz[iCentar].y-maxDist)<=y2) && ((niz[iCentar].y-maxDist)>=y1)) {b=1;}
		if (((niz[iCentar].y+maxDist)<=y2) && ((niz[iCentar].y+maxDist)>=y1)) {b=1;}
		if ((niz[iCentar].x<=x1 && niz[iCentar].x+maxDist>=x2)||(niz[iCentar].x>=x2 && niz[iCentar].x-maxDist<=x1)) {b=1;}
		if ((niz[iCentar].y<=y1 && niz[iCentar].y+maxDist>=y2)||(niz[iCentar].y>=y2 && niz[iCentar].y-maxDist<=y1)) {b=1;}
		if ((niz[iCentar].x<=x2 && niz[iCentar].x>=x1) && (niz[iCentar].y>=y1 && niz[iCentar].y<=y2)) {b=1;}
		if (b==1)
			for (int i=0; i<n; i++)
		{
			if (niz[i].x>=x1 && niz[i].x<=x2 && niz[i].y>=y1 && niz[i].y<=y2) 
			{
				if (i!=iCentar)
				{
					if (sqrt((niz[i].x-niz[iCentar].x)*(niz[i].x-niz[iCentar].x)+(niz[i].y-niz[iCentar].y)*(niz[i].y-niz[iCentar].y))<=(maxDist+0.001)) 
					{printf("%d ", i);}
				}
			}
		}
	}	
	else 
	{
		ispitajTocke(koren->s1, iCentar, maxDist, gl-1, (x1+x2)/2, x2, (y1+y2)/2, y2);
		ispitajTocke(koren->s2, iCentar, maxDist, gl-1, x1, (x1+x2)/2, (y1+y2)/2, y2);
		ispitajTocke(koren->s3, iCentar, maxDist, gl-1, x1, (x1+x2)/2, y1, (y1+y2)/2);
		ispitajTocke(koren->s4, iCentar, maxDist, gl-1, (x1+x2)/2, x2, y1, (y1+y2)/2);
	}
}

void main (int argc, char * argv[])
{
	Elem* koren=new Elem;
	char* s;
	float x1, x2, y1, y2;
	int gl=atoi(argv[2]);
	float maxDist=atof(argv[3]);
	int iCentar=atoi(argv[4]);
	FILE * fp;
	fp=fopen(argv[1], "r");
	if (fp==NULL) 
	{
		printf("Datoteka ni najdena.");
		exit(1);
	}
	fscanf(fp, "%i", &n);
	niz=new Point[n];
	for (int i=0; i<n; i++)
	{
		fscanf(fp, "%f %f", &(niz[i].x), &(niz[i].y));
		if (i==0) {x1=niz[i].x; x2=niz[i].x; y1=niz[i].y; y2=niz[i].y;}
		else 
		{
			if (x1>niz[i].x) {x1=niz[i].x;}
			if (x2<niz[i].x) {x2=niz[i].x;}
			if (y1>niz[i].y) {y1=niz[i].y;}
			if (y2<niz[i].y) {y2=niz[i].y;}
		}
	}
	if (gl>0){koren=gradnjaDrevesa (x1, x2, y1, y2, gl);}
	else 
	{
		koren->p.x=(x1+x2)/2; koren->p.y=(y1+y2)/2; 
		koren->s1=NULL; koren->s2=NULL; koren->s3=NULL; koren->s4=NULL;
	}
	ispitajTocke(koren, iCentar, maxDist, gl, x1, x2, y1, y2);
	fclose(fp);
}