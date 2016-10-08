#ifndef INMEMORYTABLEMODEL_H
#define INMEMORYTABLEMODEL_H

#include <QAbstractTableModel>
#include <QFile>
#include <QTextStream>

class InMemoryTableModel : public QAbstractTableModel
{
    Q_OBJECT
public:
    explicit InMemoryTableModel(QFile *file = 0, QObject *parent = 0);
    int rowCount(const QModelIndex &parent = QModelIndex()) const ;
    int columnCount(const QModelIndex &parent = QModelIndex()) const;
    QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const;

signals:

public slots:

private:
    QMap<int, QStringList> _data;
    int _rowCount;
    int _columnCount;
};

#endif // INMEMORYTABLEMODEL_H
