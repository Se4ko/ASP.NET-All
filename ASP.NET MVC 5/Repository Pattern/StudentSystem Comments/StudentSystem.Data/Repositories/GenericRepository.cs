namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(IStudentSystemDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();  // tva trqbva da e in-memory collection
        }

        public IQueryable<T> All
        {
            get { return this.DbSet; }
        }


        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public IStudentSystemDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}

/*  Repository<T>

Kogato rabotim s Repository vsushtnost vrushtame nqkakva in-memory collection.

Predimstva:

1. Razka4ame se ot ORM-a EF (primerno zastoto 4esto izlizat novi versii i nie mojem da testvame koq e nai dobra za nasia app)
2. Minizira se dubliciranata logika (primerno: na vsqkude v Controlleri pisha this.DBContext .. povtorqemost s Repoto go fixvame)
3. Testvaneto na nashia code.

Kakvo trqbva da sadurja edno Repository?

Add()
Remove()
Get(obj id) - obj id - zashtoto ako iskame tursim po primary key a to moje da bude: Guid, it i dr. za tva Object
Get(id)
Update() - e e hubavo, EF kato kajem Update miava i updat-va vsi4ki koloi promeneni ili nepromeneni.
GetAll()
Find(predicate)   - tozi predicate shte i pozvoli da si Filtrirame Kolekciata i da Ne Zaredim Vsi4ko v Pametta.
Primer predikat: Expression<Func<T, bool>> filterExpression   - T e tva deto podavame, a bool e tva deto vrushtame
Tozi Find i vrushta daite filtrirani.

Prosto in-memory danni. Ima mnogo mesta deto ne sadurja in-memory danni, a zaqvka kum bazata, koqto ne e materializirana.
Prosto sedi i 4aka i v momenta kogato nie imame nujda ot neq, togava da q materializirame. 
Da oba4e zashto Ne bihme vrushtali takiva: Queryable collections - zashtoto dublicirame logika na ORM-a i 
tva e nematerializirana zaqvka i sum vurzan s bazata.
Po-dobria variant e da rabotim s IEnumerable kolekcii v pametta i materializirame s edin ToList() nakraq.

____

Nedostatuci:
Imame dublicirane na logika s ORM-a: Create, Find, Remove methods
___


Kude da vikame SaveChanges()?

SaveChanges NE se vika v Repository-to. 
Polzvame Unit of Work za SaveChanges()

Unit of Work:
Dava kontrola da vikame Unit of Work kogato ni trqbva.
Kato viknem Unit of Work se zapisvat vsi4ki promeni ot repository-tata.

Zashto pravim oste edin layer vurhu EF? (DBContext-a e Unit of Work .. vika SaveChanges())

1. Totalno se razka4ame ot OR-Aa
2. Testvame si koda
3. Imame Abstrakciq
4. Imame Lesna podrujka

Vij: IStudentsSystemData.cs & StudentsSystemData.cs tva e Unit of Work 
Unit of Work trqbva da bude IDisposable obekt, zashtoto sled SaveChanges() se Dispouzva avtomati4no,
prosto go pishem prazen method.

IDisposable ni dava vuzmojnost da idem v nqkoi Action i da go izpolzvame v using blok, naprimer:

using (var unitOfWork = this.unitOfWorkFactory())
{
    this.studentsRepo.Add(studentToAdd);
    unitOfWork.Commit();  
}

***********************************************
Ninject:

AutoMapper:

***********************************************
AJAX: "Asynchronous JavaScript And XML"

Tva e tehnika za asinhronno(na background) da zarejda dinami4no nqkakuv content ot server-a.
Pozvolqva dynamic client-side changes.

Ima 2 stylana AJAX:
1. Partial page rendering - zarejdane na html fragment i pokazvaneto mu v <div> element.
2. JSON service - zarejdane JSON obekt i client-side processing s JavaScript.


Preimushtestva:

1. Asynchronous calls
2. Minimalen transfer na danni
3. Limited processing on the server
4. Responsiveness


Kofti Neshta:

Butonite za Refresh & Back sa bezpolezni.

XMLHttpRequest object:

.
.
.
.

AJAX with jQuery:




***********************************************


***********************************************



*/ 